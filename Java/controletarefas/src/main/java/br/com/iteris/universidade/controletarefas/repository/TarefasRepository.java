package br.com.iteris.universidade.controletarefas.repository;


import br.com.iteris.universidade.controletarefas.domain.entity.Tarefa;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface TarefasRepository extends JpaRepository<Tarefa, Integer> {
}
