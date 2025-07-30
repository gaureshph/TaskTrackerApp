import { BrowserRouter, Route, Routes } from "react-router-dom";
import TasksList from "./TasksList";
import Tags from "./Tags/Tags";
import DayView from "./DayView";
import MonthView from "./MonthView";
import YearView from "./YearView";
import Layout from "./Layout/Layout";
import Home from "./Home";
import TagView from "./TagView";
import WeekView from "./WeekView";

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="/" element={<Home />} />
          <Route path="/tasks" element={<TasksList />} />
          <Route path="/tags" element={<Tags />} />
          <Route path="/day/:date" element={<DayView />} />
          <Route path="/week/:date" element={<WeekView />} />
          <Route path="/month/:date" element={<MonthView />} />
          <Route path="/year/:date" element={<YearView />} />
          <Route path="/tag/:tagId" element={<TagView />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default App;
