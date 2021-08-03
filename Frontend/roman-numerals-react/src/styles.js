import styled from 'styled-components';
import { Alert } from 'react-bootstrap';

export const Container = styled.div`
  background-color: #fff;
  max-width: 800px;
  margin: 100px auto;
  padding: 50px 10px;
  border-radius: 5px;
  box-shadow: 2px 2px 10px rgba(0,0,0,.1);
`;

export const Header = styled.h1`
  text-align: center;
`;

export const FormGroup = styled.div`
  padding: 20px;
  border-radius: 10px;
`;

export const AlertStyled = styled(Alert)`
  margin-top: 10px;
`;

export const Property = styled.div`
  margin: 10px 0;
`;

export const Subtitle = styled.h4`
  text-align: center;
`;
