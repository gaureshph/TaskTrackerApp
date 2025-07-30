import { useParams } from "react-router-dom";

const DayView = () => {
  const { date } = useParams();
  return <h1>Day View for {date}</h1>;
};

export default DayView;
