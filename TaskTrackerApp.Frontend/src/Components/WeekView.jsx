import { useParams } from "react-router-dom";

const WeekView = () => {
  const { date } = useParams();
  return <h1>Week View for {date}</h1>;
};

export default WeekView;
