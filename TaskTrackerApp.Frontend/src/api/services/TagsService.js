import api from "..";

const TagsService = {
  getAll: () => api.get("api/tags"),
  addTag: (tag) => api.post("api/tags", tag),
  editTag: (tagId, tag) => api.put(`api/tags/${tagId}`, tag),
  deleteTag: (tagId) => api.delete(`api/tags/${tagId}`),
};

export default TagsService;
