import "./App.css";
import { store } from "./actions/store";
import { Provider } from "react-redux";
import { Container } from "@material-ui/core";
import { ToastProvider } from "react-toast-notifications";
import Dashboard from "./Layout/Dashboard";
import { HashRouter as Router } from "react-router-dom";

function App() {
  return (
    <Provider store={store}>
      <ToastProvider autoDismiss={true}>
        <Container maxWidth="lg">
          <Router>
            <Dashboard />
          </Router>
        </Container>
      </ToastProvider>
    </Provider>
  );
}

export default App;
