import styled from "styled-components";

export const Wrapper = styled.div`
  display: flex;
  flex-direction: column;
  gap: 15px;
`;

export const TitleContainer = styled.div`
  font-size: 25px;
  font-weight: 600;
`;

export const MessageContainer = styled.div``;

export const ButtonContainer = styled.div`
  text-align: right;
  display: flex;
  input {
    display: flex;
    min-width: 140px;
    &:active,
    &:focus {
      outline: none !important;
      box-shadow: none !important;
    }
  }
  button {
    background: lightblue;
    border: 1px solid black;
    border-radius: 6px;
    padding: 8px;
    cursor: pointer;
    display: flex;
    margin-left: auto;
  }
`;
