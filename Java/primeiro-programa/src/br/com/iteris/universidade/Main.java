package br.com.iteris.universidade;

import java.util.Scanner;

import br.com.iteris.universidade.modelos.Cliente;
import br.com.iteris.universidade.modelos.Usuario;

public class Main {

    private static final Scanner reader = new Scanner(System.in);

    public static void main(String[] args) {
        double n = 3.14159;
        double raio = reader.nextDouble();

        double a = n * raio * raio;

        System.out.printf("A=%.4f\n", a);

        Cliente clienteA = new Cliente();
        clienteA.setNome("Douglas");
        clienteA.setSobreNome("Fernandes");
        System.out.println(clienteA.getNomeCompleto());
        System.out.println(clienteA.faltaQuantosAnosPara(40));

        var clienteB = new Cliente(22);
        clienteB.setNome("Joao");
        clienteB.setSobreNome("zinho");
        System.out.println(clienteB.getNomeCompleto());
        System.out.println(clienteB.faltaQuantosAnosPara(40));

        var usuarioA = new Usuario();
        usuarioA.setNome("Thiago");
        usuarioA.setEmail("thiago.borba@iteris.com.br");
        System.out.println(usuarioA.getLogin());


    }
}
