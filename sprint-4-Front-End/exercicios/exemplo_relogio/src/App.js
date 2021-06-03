import { render } from '@testing-library/react';
import React from 'react';
import './App.css';

function DataFormatada(props){
  return <h2>Horário atual: {props.date.toLocaleTimeString()}</h2>
}

class Clock extends React.Component{
  constructor(props){
    super(props);
    this.state ={
      date : new Date()
    };
    this.pararRelogio = this.pararRelogio.bind(this);
    this.retomarRelogio = this.retomarRelogio.bind(this);
  }

  componentDidMount(){
    this.timerID = setInterval( () => {
      this.thick() 
    }, 1000);

    console.log("Eu sou o relógio "+ this.timerID)
  }

  componentWillUnmount(){
    clearInterval(this.timerID)
  }

  pararRelogio(){
    clearInterval(this.timerID)
    console.log("Relógio "+ this.timerID +" Pausado")
  }
  retomarRelogio(){
    this.timerID = setInterval( () => {
      this.thick() 
    }, 1000);
    console.log("Relógio Retomado")
    console.log("Agora sou o relógio "+ this.timerID)
  }

  thick(){
    this.setState({
      date : new Date()
    });
  }
  render(){
    return (
      <div>
        <h1>Relógio</h1>
        <DataFormatada date={this.state.date} />
        <button onClick={this.pararRelogio}>
        Parar
        </button>
        <button onClick={this.retomarRelogio}>
        Retomar
        </button>
      </div>
    );
  }
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

export default App;
