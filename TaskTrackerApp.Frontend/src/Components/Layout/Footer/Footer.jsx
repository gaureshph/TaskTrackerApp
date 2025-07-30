import { FooterWrapper } from "./Footer.styles";

const Footer = () => {
  return (
    <FooterWrapper>
      <div>© 2025 Gouresh Phadke. Built with React, .Net Core and MS SQL</div>
      <div>
        <a href="https://www.linkedin.com/in/gauresh-phadke">LinkedIn</a> |
        <a href="https://github.com/gaureshph">GitHub</a> | Resume |{" "}
        <a href="mailto:gauresh.phadke@yahoo.com">gauresh.phadke@yahoo.com</a> |{" "}
        <a href="tel:+919881663481">+91 98816 63481</a>
      </div>
    </FooterWrapper>
  );
};

export default Footer;
