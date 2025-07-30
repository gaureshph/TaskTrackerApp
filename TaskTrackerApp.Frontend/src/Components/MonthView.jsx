import { useParams } from "react-router-dom";

const MonthView = () => {
  const { date } = useParams();
  return <h1>Month View for {date}</h1>;
};

export default MonthView;
