import { useContext } from "react";
import ListaTarefasContext from "./ListaTarefasContext";

//Hook que vamos usar no componente
const useListaTarefas = () => useContext(ListaTarefasContext);
export default useListaTarefas;
