import api from "..";

const TasksService = {
    getAll: () => api.get("api/tasks")
}

export default TasksService;