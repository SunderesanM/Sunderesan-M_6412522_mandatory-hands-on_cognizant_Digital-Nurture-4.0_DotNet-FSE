import { books } from "../store/BookDetails";

export const Book = () => {
  return (
    <div>
      <h1>Course Details</h1>
      {books.map((book, index) => (
        <ul key={index}>
          <h2><strong>{book.bname}</strong></h2>
          <h3>{book.price}</h3>
        </ul>
      ))}
    </div>
  );
};