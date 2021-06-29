import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Jumbotron, Alert } from 'react-bootstrap';
import BootstrapTable from 'react-bootstrap-table-next';
import axios from 'axios';
import './App.css';

function App() {

  const [roman, setRomanValue] = useState("");
  const [decimal, setDecimalValue] = useState("");
  const [explainedValues, setExplainedValues] = useState([]);
  const [message, setMessage] = useState("");
  const [focus, setFocus] = useState("");

  const convert = async (type, value) => {
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

      await axios.get(`https://localhost:49153/api/RomanNumerals/Parse/${value}`)
        .then(function (response) {
          const decimalValue = response.data.decimalValue.toString();
          const romanValue = response.data.romanNumeralValue.toString();

          setMessage("");
          setDecimalValue(decimalValue);
          setRomanValue(romanValue);
          setExplainedValues(response.data.explainedValue);
        })
        .catch(function (error) {
          const tempDec = error.response.data.decimalValue;
          const tempRom = error.response.data.romanNumeralValue;

          const decimalValue = tempDec ? tempDec.toString() : "";
          const romanValue = tempRom ? tempRom.toString() : "";

          setMessage(error.response.data.message);
          setDecimalValue(decimalValue);
          setRomanValue(romanValue);
          setExplainedValues([]);
        });
    }
    else {
      setMessage("");
      setRomanValue("");
      setDecimalValue("");
      setExplainedValues([]);
    }
  }

  useEffect(() => {
    document.getElementById("roman").value = roman;
    document.getElementById("decimal").value = decimal;
  });

  const tableColumns = [{
    dataField: "sequence",
    text: "#",
    align: "center",
    headerAlign: "center"
  }, {
    dataField: "roman",
    text: "Roman",
    align: "center",
    headerAlign: "center"
  }, {
    dataField: "value",
    text: "Value",
    align: "center",
    headerAlign: "center"
  }];

  return (
    <Container className="p-5">
      <Jumbotron>
        <h1 className="header">Roman Numerals</h1>
          <div className="form-group">
            <Row>
              <Col xs={1}><label style={{marginTop: "4px", fontSize: "18px"}}>Roman: </label></Col>
              <Col xs={3}>
                <input type="text" class="form-control" id="roman" placeholder="Roman Numeral Value" onKeyUp={(e) => convert(e.target.id, e.target.value.toUpperCase())}></input>
              </Col>
              {focus === "roman" && message !== "" ? <Alert id="romanError" variant={'danger'} style={{paddingBottom: "6px", paddingTop: "6px"}}>{message}</Alert> : null}
            </Row>
            <Row style={{marginTop: "10px"}}>
              <Col xs={1}><label style={{marginTop: "4px", fontSize: "18px"}}>Decimal: </label></Col>
              <Col xs={3}>
                <input type="text" class="form-control" id="decimal" placeholder="Decimal Value" onKeyUp={(e) => convert(e.target.id, e.target.value.toUpperCase())}></input>
              </Col>
              {focus === "decimal" && message !== "" ? <Alert id="decimalError" variant={'danger'} style={{paddingBottom: "6px", paddingTop: "6px"}}>{message}</Alert> : null}
            </Row>
            {explainedValues.length > 0 ?
            <>
              <Row style={{marginTop: "20px"}}>
                <Col xs={6}>
                  <h4>Why this value?:</h4>
                </Col>
              </Row>
              <Row>
                <Col xs={6}>
                  <BootstrapTable bootstrap4 keyField='sequence' data={ explainedValues } columns={ tableColumns } noDataIndication="None value to show" striped hover condensed />
                </Col>
              </Row>
            </>: null }
          </div>
      </Jumbotron>
    </Container>
  );
}

export default App;
