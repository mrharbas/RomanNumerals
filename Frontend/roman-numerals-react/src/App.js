import React, { useState, useEffect } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import axios from 'axios';
import {
  Container,
  FormGroup,
  Header,
  Property,
  Subtitle,
  AlertStyled,
} from './styles.js';

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

      await axios.get(`https://localhost:49155/api/RomanNumerals/Parse/${value}`)
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
      <Container>
        <Header>Roman Numerals</Header>
        <FormGroup>
          <label htmlFor="roman">Roman:</label>
          <Property>
            <input
              id="roman"
              type="text"
              class="form-control"
              placeholder="Roman Numeral Value"
              onKeyUp={(e) => convert(e.target.id, e.target.value.toUpperCase())}
            />
            {focus === "roman" && message !== "" &&
              <AlertStyled id="romanError" variant={'danger'}>
                {message}
              </AlertStyled>
            }
          </Property>
          <label htmlFor="decimal">Decimal:</label>
          <Property>
            <input
              id="decimal"
              type="text"
              class="form-control"
              placeholder="Decimal Value"
              onKeyUp={(e) => convert(e.target.id, e.target.value.toUpperCase())}
            />
            {focus === "decimal" && message !== "" &&
              <AlertStyled id="decimalError" variant={'danger'}>
                {message}
              </AlertStyled>
            }
          </Property>
          {explainedValues.length > 0 &&
            <Property>
              <Subtitle>Why this value?</Subtitle>
              <BootstrapTable
                bootstrap4
                keyField='sequence'
                data={explainedValues}
                columns={tableColumns}
                noDataIndication="None value to show"
                striped
                hover
                condensed
              />
            </Property>
          }
        </FormGroup>
      </Container>
  );
}

export default App;
