import styled from "styled-components";

export const Table = styled.table`
  border-spacing: 0;
  th {
    text-align: left;
    border: 1px solid gray;
    padding: 10px;
  }
  td {
    border: 1px solid gray;
    padding: 10px;
    button {
      border: 1px solid black;
      border-radius: 6px;
      padding: 6px 8px;
      cursor: pointer;
      &.editButton {
        background-color: royalblue;
      }
      &.deleteButton {
        margin-left: 5px;
        background-color: red;
      }
    }
  }
`;
