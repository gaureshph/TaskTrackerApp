import TagsService from "../../api/services/TagsService";
import Modal from "react-modal";
import {
  Wrapper,
  ButtonContainer,
  TitleContainer,
  MessageContainer,
} from "./Tags.styles";
import { useEffect, useState } from "react";
import TagsTable from "./TagsTable/TagsTable";

const Tags = () => {
  const [tags, setTags] = useState([]);
  const [tagName, setTagName] = useState("");
  const [filteredTags, setFilteredTags] = useState([]);
  const [filterText, setFilterText] = useState("");
  const [isAddTagModalOpen, setIsAddTagModalOpen] = useState(false);

  useEffect(() => {
    TagsService.getAll().then((res) => {
      setTags(res.data);
      setFilteredTags(res.data);
    });
  }, []);

  const handleAddTagClicked = () => {
    TagsService.addTag({ name: tagName }).then((res) => {
      setTags([...tags], res.data);
      setIsAddTagModalOpen(false);
    });
  };

  return (
    <Wrapper>
      <TitleContainer>
        <div>Tags</div>
      </TitleContainer>
      <ButtonContainer>
        <input
          placeholder="Search tags"
          value={filterText}
          onChange={(e) => setFilterText(e.target.value)}
        />
        <button onClick={() => setIsAddTagModalOpen(true)}>Add Tag</button>
      </ButtonContainer>
      {!tags || tags.length <= 0 ? (
        <MessageContainer>No tags were found</MessageContainer>
      ) : !filteredTags || filteredTags.length <= 0 ? (
        <MessageContainer>No tag matches the filter text</MessageContainer>
      ) : (
        <TagsTable filteredTags={filteredTags} />
      )}
      <Modal
        isOpen={isAddTagModalOpen}
        onRequestClose={() => setIsAddTagModalOpen(false)}
      >
        <h2>Add Tag</h2>
        <div>Tag Name:</div>
        <input value={tagName} onChange={(e) => setTagName(e.target.value)} />
        <button onClick={handleAddTagClicked}>Add</button>
        <button onClick={() => setIsAddTagModalOpen(false)}>Close</button>
      </Modal>
    </Wrapper>
  );
};

export default Tags;
