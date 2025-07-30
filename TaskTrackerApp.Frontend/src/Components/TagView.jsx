import { useParams } from "react-router-dom";

const TagView = () => {
  const { tagId } = useParams();
  return <h1>Tag View for {tagId}</h1>;
};

export default TagView;
