package br.com.iteris.universidade.modelos;

import java.util.Spliterator;

public class Usuario {
    public Usuario() { }
    public Usuario(String nome, String email) {
        this.nome = nome;
        this.email = email;
    }

    private String nome;
    private String email;

    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }
    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }

    public String getLogin() {
        String response =  this.email.split("@")[0];
        return response;
    }

}
