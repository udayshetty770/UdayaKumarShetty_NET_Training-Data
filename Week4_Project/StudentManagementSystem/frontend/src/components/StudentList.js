import React from "react";
import { deleteStudent } from "../services/api";

function StudentList({ students, onEdit, refreshList }) {
  const handleDelete = async (id) => {
    if (!window.confirm("Delete this student?")) return;
    await deleteStudent(id);
    refreshList();
  };

  return (
    <div className="card shadow-sm mt-4 p-3">
      <h4 className="mb-3 text-center">Student List</h4>
      <table className="table table-striped">
        <thead className="table-dark">
          <tr>
            <th>ID</th><th>Name</th><th>Age</th><th>Grade</th><th>Course ID</th><th>Course Name</th><th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {students.length === 0 ? (
            <tr><td colSpan="7" className="text-center text-muted">No students found</td></tr>
          ) : students.map(s => (
            <tr key={s.id}>
              <td>{s.id}</td>
              <td>{s.name}</td>
              <td>{s.age}</td>
              <td>{s.grade}</td>
              <td>{s.courseId ?? "-"}</td>
              <td>{s.courseName ?? "-"}</td>
              <td>
                <button className="btn btn-sm btn-primary me-2" onClick={() => onEdit(s)}>Edit</button>
                <button className="btn btn-sm btn-danger" onClick={() => handleDelete(s.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default StudentList;
