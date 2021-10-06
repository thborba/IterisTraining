import axios from "axios";

export function getImoveis() {
  return axios.get("http://localhost:8080/imoveis").then((AxiosResponse) => {
    return AxiosResponse.data;
  });
}
