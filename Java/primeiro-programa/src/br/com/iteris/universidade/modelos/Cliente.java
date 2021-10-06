package br.com.iteris.universidade.modelos;
// [modificador de acesso] - [class] - [identificador]
public class Cliente {
    public Cliente() { } //construtor simples
    public Cliente(int idade) {
        this.idade = idade; //this.idade para diferencia o campo do parametro
    }
    // atributos - declarações
    // [modificador de acesso] - [Tipo de retorno] - [identificador]
    private int idade;
    private String nome;
    private String sobreNome;
    // propriedades - getter e setter
    // [modificador de acesso] - [Tipo de retorno] - [identificador]
    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }
    public String getSobreNome() {
        return sobreNome;
    }
    public void setSobreNome(String sobreNome) {
        this.sobreNome = sobreNome;
    }
    // métodos internos
    // [modificador de acesso] - [Tipo de retorno] - [identificador]
    public String getNomeCompleto() {
        return this.nome + " " + this.sobreNome;
    }
    public String faltaQuantosAnosPara(int idadeAlvo) {
        int diferenca = idadeAlvo - idade;
        if (diferenca >= 0)
            return "Falta(m) " + diferenca + " Anos(s)";
        else {
            return "Já passou da idade";
        }
    }
}