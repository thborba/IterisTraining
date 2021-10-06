import "./App.css";
import SobrePage from "./pages/SobrePage";
import HomePage from "./pages/HomePage";
import ImoveisPage from "./pages/ImoveisPage";
import MenuPageTemplate from "./pageTemplates/MenuPageTemplate";
import { BrowserRouter, Switch, Route } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <MenuPageTemplate>
        <Switch>
          <Route path="/" exact={true}>
            <HomePage />
          </Route>
          <Route path="/sobre" exact={true}>
            <SobrePage />
          </Route>
          <Route path="/imoveis" exact={true}>
            <ImoveisPage />
          </Route>
        </Switch>
      </MenuPageTemplate>
    </BrowserRouter>
  );
}

export default App;
