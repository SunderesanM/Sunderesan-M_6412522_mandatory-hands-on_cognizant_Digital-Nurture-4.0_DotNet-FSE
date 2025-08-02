import React from "react";
import { courses } from "../store/CourseDetails";

export const Course = () => {
  return (
    <div>
      <h1>Course Details</h1>
      {courses.map((course, index) => (
        <ul key={index}>
          <h2><strong>{course.name}</strong></h2>
          <h3>{course.date}</h3>
        </ul>
      ))}
    </div>
  );
};