import { Outlet } from "react-router-dom";
import { ContentWrapper, LayoutWrapper, Main } from "./Layout.styles";
import Header from "./Header/Header";
import Sidebar from "./Sidebar/Sidebar";
import Footer from "./Footer/Footer";

const Layout = () => {
  return (
    <LayoutWrapper>
      <Header />
      <ContentWrapper>
        <Sidebar />
        <Main>
          <Outlet />
        </Main>
      </ContentWrapper>
      <Footer />
    </LayoutWrapper>
  );
};

export default Layout;
