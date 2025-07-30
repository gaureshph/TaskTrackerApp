import TagsService from "../../../api/services/TagsService";
import { Table } from "./TagsTable.styles";
import { useState } from "react";
import Modal from "react-modal";

const TagsTable = ({ filteredTags }) => {
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [tagName, setTagName] = useState("");
  const [tagId, setTagId] = useState(0);

  const handleEdit = (tag) => {
    setTagId(tag.id);
    setTagName(tag.name);
    setIsEditModalOpen(true);
  };

  const handleDelete = (tag) => {
    setTagId(tag.id);
    setTagName(tag.name);
    setIsDeleteModalOpen(true);
  };

  const handleSaveClicked = () => {
    TagsService.editTag(tagId, { name: tagName }).then(() => {
      setIsEditModalOpen(false);
    });
  };

  const handleConfirmClicked = () => {
    TagsService.deleteTag(tagId).then(() => {
      setIsDeleteModalOpen(false);
    });
  };

  return (
    <>
      <Table>
        <thead>
          <tr>
            <th style={{ width: "70%" }}>Tag Name</th>
            <th style={{ width: "30%" }}>Actions</th>
          </tr>
        </thead>
        <tbody>
          {filteredTags.map((tag) => {
            return (
              <tr key={tag.id}>
                <td>{tag.name}</td>
                <td>
                  <button
                    onClick={() => {
                      handleEdit(tag);
                    }}
                    className="editButton"
                  >
                    Edit
                  </button>
                  <button
                    onClick={() => {
                      handleDelete(tag);
                    }}
                    className="deleteButton"
                  >
                    Delete
                  </button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
      <Modal
        isOpen={isEditModalOpen}
        onRequestClose={() => setIsEditModalOpen(false)}
      >
        <h2>Edit Tag</h2>
        <div>Tag Name:</div>
        <input value={tagName} onChange={(e) => setTagName(e.target.value)} />
        <button onClick={handleSaveClicked}>Save</button>
        <button onClick={() => setIsEditModalOpen(false)}>Close</button>
      </Modal>
      <Modal
        isOpen={isDeleteModalOpen}
        onRequestClose={() => setIsDeleteModalOpen(false)}
      >
        <h2>Delete Tag</h2>
        <div>Are you sure you want to delete the tag '{tagName}'?</div>
        <button onClick={handleConfirmClicked}>Confirm</button>
        <button onClick={() => setIsDeleteModalOpen(false)}>Cancel</button>
      </Modal>
    </>
  );
};

export default TagsTable;
