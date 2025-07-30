import styled from "styled-components";

export const SidebarWrapper = styled.aside`
  display: flex;
  flex-direction: column;
  width: 240px;
  border-right: 1px solid gray;
  a {
    display: flex;
    text-decoration: none;
    color: #333;
    font-weight: 500;
    height: 50px;
    padding-left: 40px;
    align-items: center;
    border-bottom: 1px solid gray;
  }
`;
