import { blogs } from "../store/BlogDetails";

export const Blog = () => {
  return (
    <div>
      <h1>Course Details</h1>
      {blogs.map((blog, index) => (
        <ul key={index}>
          <h2><strong>{blog.title}</strong></h2>
          <h3>{blog.author}</h3>
          <h4>{blog.content}</h4>
        </ul>
      ))}
    </div>
  );
};