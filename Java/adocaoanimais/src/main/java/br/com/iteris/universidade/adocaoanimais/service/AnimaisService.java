package br.com.iteris.universidade.adocaoanimais.service;

import br.com.iteris.universidade.adocaoanimais.domain.dto.AnimalCreateRequest;
import br.com.iteris.universidade.adocaoanimais.domain.dto.AnimalUpdateRequest;
import br.com.iteris.universidade.adocaoanimais.domain.entity.Animal;
import br.com.iteris.universidade.adocaoanimais.exception.AnimalDataNascimentoInvalidaException;
import br.com.iteris.universidade.adocaoanimais.exception.AnimalEspecieInvalidaException;
import br.com.iteris.universidade.adocaoanimais.exception.AnimalNaoEncontradoException;
import org.springframework.stereotype.Service;

import java.sql.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.Instant;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

@Service
public class AnimaisService {
    private static List<Animal> listaDeAnimais;
    private static int proximoId = 1;

    public AnimaisService(){
        listaDeAnimais = new ArrayList<>();

    }

    public Animal criarAnimal(AnimalCreateRequest model) {

        if (model.getDataNasimcento() != null ) {
            if(model.getDataNasimcento().isAfter(java.time.LocalDate.now()))
                throw new AnimalDataNascimentoInvalidaException();
        }

        if (!model.getEspecie().equals("Cachorro")  && !model.getEspecie().equals("Capivara") && !model.getEspecie().equals("Gato") && !model.getEspecie().equals("Coelho"))
            throw new AnimalEspecieInvalidaException();

        var novoAnimal = new Animal(proximoId++, model.getNome(), model.getIdade(), model.getEspecie(), model.getDataNasimcento(), model.getFofura(), model.getCarinho(), model.getEmail());

        listaDeAnimais.add(novoAnimal);

        return novoAnimal;
    }

    public List<Animal> listar() {
        return listaDeAnimais;
    }
    
    public Animal buscarPorId(Integer idAnimal) {
        var animalEncontrado = listaDeAnimais.stream()
                .filter(animal -> animal.getId() == idAnimal)
                .findFirst();

        if (animalEncontrado.isEmpty()) {
            throw new AnimalNaoEncontradoException();
        }

        return animalEncontrado.get();
    }

    public Animal buscarPorNome(String nome) {
        var animalEncontrado = listaDeAnimais.stream()
                .filter(animal -> animal.getNome().equals(nome))
                .findFirst();

        if (animalEncontrado.isEmpty()) {
            throw new AnimalNaoEncontradoException();
        }

        return animalEncontrado.get();
    }

    public Animal atualizarAnimal(Integer idAnimal, AnimalUpdateRequest model) {
        var animalEncontrado = listaDeAnimais.stream()
                .filter(animal -> animal.getId() == idAnimal)
                .findFirst();

        if (animalEncontrado.isEmpty()) {
            throw new AnimalNaoEncontradoException();
        }

        var animal = animalEncontrado.get();

        animal.setCarinho(model.getCarinho());
        animal.setFofura(model.getFofura());

        return animalEncontrado.get();
    }

    public Animal deletarAnimal(Integer idAnimal) {
        var animalEncontrado = listaDeAnimais.stream()
                .filter(animal -> animal.getId() == idAnimal)
                .findFirst();

        if (animalEncontrado.isEmpty()) {
            throw new AnimalNaoEncontradoException();
        }

        var animal = animalEncontrado.get();
        listaDeAnimais.remove(animal);

        return animal;
    }

}
