import { useParams } from "react-router-dom";

const YearView = () => {
  const { date } = useParams();
  return <h1>Year View for {date}</h1>;
};

export default YearView;
