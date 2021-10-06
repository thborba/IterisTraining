import TarefaModel from "../../models/TarefaModel";

//função de construção do objeto que vamos compartilhar
//Usada na inicialização
export function listaTarefasContextBuilder([
  listaDeTarefas,
  setListaDeTarefas,
]) {
  return {
    listaDeTarefas,
    adicionarTarefa: (tarefa) =>
      setListaDeTarefas(adicionar(listaDeTarefas, tarefa)),
    atualizarStatus: (tarefa) =>
      setListaDeTarefas(editar(listaDeTarefas, tarefa)),
    limparLista: () => {
      setListaDeTarefas([]);
    }
  };
}

// funções privadas para tratamento de dados
function adicionar(listaDeTarefas, descricaoTarefa) {
  const novaTarefa = new TarefaModel(
    listaDeTarefas.length + 1,
    descricaoTarefa
  );
  return [...listaDeTarefas, novaTarefa];
}

function editar(listDeTarefas, tarefa) {
  //atualizada o campo concluida e cria um objeto novo
  const tarefaAtualizada = { ...tarefa, concluida: !tarefa.concluida };

  //Criar uma lista nova e atualiza a tarefa antiga
  const ListaAtualizada = listDeTarefas.map((x) => {
    if (x.id !== tarefa.id) {
      return x;
    } else {
      return tarefaAtualizada;
    }
  });
  return ListaAtualizada;
}
