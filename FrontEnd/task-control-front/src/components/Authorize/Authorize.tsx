import React, { FC } from 'react';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import styles from './Authorize.module.css';
import Button from 'react-bootstrap/Button';
import { Container, FloatingLabel, Row } from 'react-bootstrap';

interface AuthorizeProps {}

const Authorize: FC<AuthorizeProps> = () => (
  <Container>
    <Row></Row>
    <Row className=''>
  <Container>
    <Row>
      <FloatingLabel
        label="Login"
        className="mb-3"
      >
        <Form.Control
          placeholder="Login"
          aria-label="Login"
          aria-describedby="basic-addon1"
        />
      </FloatingLabel>
    </Row>
    <Row>
    <FloatingLabel
        label="Password"
        className="mb-3"
      >
      <Form.Control
        type="password"
        id="inputPassword5"
        aria-describedby="passwordHelpBlock"
      />
      </FloatingLabel>
    </Row>
    <Row>
    <InputGroup className="mb-3">
      <Button type="submit">Login</Button>
      </InputGroup>
    </Row>
  </Container>
  </Row>
  <Row></Row>
  </Container>
);

export default Authorize;
