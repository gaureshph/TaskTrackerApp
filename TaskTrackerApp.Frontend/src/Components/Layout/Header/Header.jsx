import { Link } from "react-router-dom";
import { BrandContainer, HeaderWrapper, Nav } from "./Header.styles";

const Header = () => {
  return (
    <HeaderWrapper>
      <BrandContainer>
        <Link to="/">Task Tracker</Link>
      </BrandContainer>
      <Nav>
        <Link to="/">Home</Link>
        <Link to="/tasks">Tasks</Link>
        <Link to="/tags">Tags</Link>
      </Nav>
    </HeaderWrapper>
  );
};

export default Header;
