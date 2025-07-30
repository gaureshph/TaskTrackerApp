import TasksService from "../api/services/TasksService";
import { useEffect, useState } from "react";

const TasksList = () => {
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    // TasksService.getAll().then((response) => {
    //   setTasks(response.data);
    // });
  }, []);

  if (!tasks || tasks.length <= 0) 
    return <div>No tasks were found</div>;

  return tasks.map((task) => <div>{task.title}</div>);
};

export default TasksList;
