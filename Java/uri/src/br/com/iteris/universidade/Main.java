package br.com.iteris.universidade;
import java.util.Scanner;

public class Main {
    private static final Scanner reader = new Scanner(System.in);

    public static void main(String[] args) {
        System.out.println("Hello");
    }

    public void URI1050() {
        int ddd = reader.nextInt();

        switch (ddd) {
            case 61:
                System.out.println("Brasilia");
                break;
            case 71:
                System.out.println("Salvador");
                break;
            case 11:
                System.out.println("Sao Paulo");
                break;
            case 21:
                System.out.println("Rio de Janeiro");
                break;
            case 32:
                System.out.println("Juiz de Fora");
                break;
            case 19:
                System.out.println("Campinas");
                break;
            case 27:
                System.out.println("Vitoria");
                break;
            case 31:
                System.out.println("Belo Horizonte");
                break;
            default:
                System.out.println("DDD nao cadastrado");
                break;

        }
    }

    public void URI1074() {
        int n = reader.nextInt();

        for (int i = 0; i < n; i++) {
            int x = reader.nextInt();

            String print;

            if (x == 0)
                print = "NULL";
            else {
                if (x % 2 == 0)
                    print = "EVEN";
                else
                    print = "ODD";

                if (x < 0)
                    print += " NEGATIVE";
                else
                    print += " POSITIVE";
            }

            System.out.println(print);
        }
    }

    public void URI1140() {
        String input;
        do {
            input = reader.nextLine();
            if (!input.equals("*")) {
                String[] splited = input.toLowerCase().split(" ");
                boolean aux = true;
                char firstLetter = splited[0].charAt(0);
                for (int i = 1; i < splited.length; i++) {
                    if (splited[i].length() > 20 || splited[i].charAt(0) != firstLetter) {
                        aux = false;
                        break;
                    }
                }

                if (aux)
                    System.out.println("Y");
                else
                    System.out.println("N");

            }

        } while (!input.equals("*"));


    }

    public void URI1153() {
        int n = reader.nextInt();

        int resultado = 1;

        while (n != 1) {
            resultado = resultado * n;
            n = n - 1;
        }
        System.out.println(resultado);
    }

    public void URI1160() {
        int n = Integer.parseInt(reader.nextLine());
        for (int i = 0; i < n; i++) {

            String input = reader.nextLine();
            String[] splited = input.split(" ");

            int PA = Integer.parseInt(splited[0]);
            int PB = Integer.parseInt(splited[1]);
            double G1 = Double.parseDouble(splited[2]);
            double G2 = Double.parseDouble(splited[3]);

            int count = 0;

            while (PA <= PB && count <= 100) {
                PA += (int) (PA * G1 / 100);
                PB += (int) (PB * G2 / 100);
                count++;
            }

            if (count > 100)
                System.out.println("Mais de 1 seculo.");
            else
                System.out.println(count + " anos.");

        }
    }

    public void URI1272() {
        int n = Integer.parseInt(reader.nextLine());
        for (int i = 0; i < n; i++) {

            String input = reader.nextLine();
            String[] splited = input.trim().split(" ");

            for (String s : splited) {
                if (!s.equals(""))
                    System.out.print(s.charAt(0));
            }
            System.out.println("");


        }
    }

    public void URI2593() {
        String input = reader.nextLine();
        String[] splited = input.trim().toLowerCase().split(" ");

        int n = Integer.parseInt(reader.nextLine());
        String[] pesquisa = reader.nextLine().split(" ");

        for (String s : pesquisa){
            int nLetras = 0, aux = 0;
            for (int j = 0; j < splited.length; j++) {
                if (splited[j].equals(s)) {
                    if(aux >= 1)
                        System.out.print(" " + (nLetras + j));
                    else
                        System.out.print(nLetras + j );
                    aux++;
                }
                nLetras += splited[j].length();
            }
            if(aux == 0)
                System.out.print(-1);

            System.out.println("");

        }
    }

    public void URI2594() {
        int n = Integer.parseInt(reader.nextLine());
        for (int i = 0; i<n; i++) {
            String input = reader.nextLine();
            String[] splited = input.trim().toLowerCase().split(" ");
            String pesquisa = reader.nextLine();
            int nLetras = 0, aux = 0;
            for (int j = 0; j < splited.length; j++) {
                if (splited[j].equals(pesquisa)) {

                    if (aux >= 1)
                        System.out.print(" " + (nLetras + j));
                    else
                        System.out.print(nLetras + j);
                    aux++;
                }
                nLetras += splited[j].length();
            }
            if (aux == 0)
                System.out.print(-1);
            System.out.println();
        }
    }

    public void URI2830() {
        int n1 = reader.nextInt();
        int n2 = reader.nextInt();

        if ((n1 - 1) / 2 == (n2 - 1) / 2)
            System.out.println("oitavas");
        else if ((n1 - 1) / 4 == (n2 - 1) / 4)
            System.out.println("quartas");
        else if ((n1 - 1) / 8 == (n2 - 1) / 8)
            System.out.println("semifinal");
        else
            System.out.println("final");
    }
}


