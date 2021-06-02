import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Jumbotron, Alert } from 'react-bootstrap';
import axios from 'axios';
import './App.css';

function App() {

  const [roman, setRomanValue] = useState("");
  const [decimal, setDecimalValue] = useState("");
  const [message, setMessage] = useState("");
  const [focus, setFocus] = useState("");

  const convert = (type, value) => {
    if (value && value.length > 0 && value.trim() !== "") {
      if (type === "roman" && !isNaN(value)) {
        document.getElementById("decimal").focus();
        type = "decimal";
      }
      else if (type === "decimal" && isNaN(value)) {
        document.getElementById("roman").select();
        type = "roman";
      }

      setFocus(type);

      axios.get(`https://localhost:49153/api/RomanNumerals/Parse/${value}`)
        .then(function (response) {
          const decimalValue = response.data.decimalValue.toString();
          const romanValue = response.data.romanNumeralValue.toString();

          setMessage("");
          setDecimalValue(decimalValue);
          setRomanValue(romanValue);
        })
        .catch(function (error) {
          const tempDec = error.response.data.decimalValue;
          const tempRom = error.response.data.romanNumeralValue;

          const decimalValue = tempDec ? tempDec.toString() : "";
          const romanValue = tempRom ? tempRom.toString() : "";

          setMessage(error.response.data.message);
          setDecimalValue(decimalValue);
          setRomanValue(romanValue);
        });
    }
    else {
      setMessage("");
      setRomanValue("");
      setDecimalValue("");
    }
  }

  useEffect(() => {
    document.getElementById("roman").value = roman;
    document.getElementById("decimal").value = decimal;
  });

  return (
    <Container className="p-5">
      <Jumbotron>
        <h1 className="header">Roman Numerals</h1>
          <div className="form-group">
            <Row>
              <Col xs={1}><label style={{marginTop: "4px", fontSize: "18px"}}>Roman: </label></Col>
              <Col xs={3}>
                <input type="text" class="form-control" id="roman" placeholder="Roman Numeral Value" onChange={(e) => convert(e.target.id, e.target.value.toUpperCase())}></input>
              </Col>
              {focus === "roman" && message !== "" ? <Alert variant={'danger'} style={{paddingBottom: "6px", paddingTop: "6px"}}>{message}</Alert> : null}
            </Row>
            <Row style={{marginTop: "10px"}}>
              <Col xs={1}><label style={{marginTop: "4px", fontSize: "18px"}}>Decimal: </label></Col>
              <Col xs={3}>
                <input type="text" class="form-control" id="decimal" placeholder="Decimal Value" onChange={(e) => convert(e.target.id, e.target.value.toUpperCase())}></input>
              </Col>
              {focus === "decimal" && message !== "" ? <Alert variant={'danger'} style={{paddingBottom: "6px", paddingTop: "6px"}}>{message}</Alert> : null}
            </Row>
          </div>
      </Jumbotron>
    </Container>
  );
}

export default App;
