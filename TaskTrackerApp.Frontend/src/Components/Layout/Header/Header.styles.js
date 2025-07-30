import styled from "styled-components";

export const HeaderWrapper = styled.header`
  display: flex;
  height: 50px;
  border-bottom: 1px solid gray;
`;

export const Nav = styled.nav`
  display: flex;
  gap: 10px;
  padding: 14px 0 14px 10px;
  a {
    text-decoration: none;
    color: #333;
    font-weight: 500;
    padding: 0 8px;

    &:hover {
      color: #007bff;
    }
  }
`;

export const BrandContainer = styled.div`
  display: flex;
  width: 240px;
  justify-content: center;
  align-items: center;
  a {
    text-decoration: none;
    color: #333;
    font-weight: 500;
  }
`;
