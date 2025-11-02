import React, { useState, useEffect } from "react";
import { addStudent, updateStudent } from "../services/api";

function StudentForm({ selected, refreshList, clearSelection }) {
  const [form, setForm] = useState({ name: "", age: "", grade: "", courseId: "" });

  useEffect(() => {
    if (selected) {
      setForm({
        name: selected.name || "",
        age: selected.age || "",
        grade: selected.grade || "",
        courseId: selected.courseId || "",
      });
    } else {
      setForm({ name: "", age: "", grade: "", courseId: "" });
    }
  }, [selected]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!form.name || !form.age) {
      alert("Name and Age are required");
      return;
    }

    const data = {
      name: form.name,
      age: parseInt(form.age, 10),
      grade: form.grade,
      courseId: form.courseId ? parseInt(form.courseId, 10) : null
    };

    try {
      if (selected) {
        await updateStudent(selected.id, data);
        alert("Student updated");
      } else {
        await addStudent(data);
        alert("Student added");
      }
      refreshList();
      clearSelection();
      setForm({ name: "", age: "", grade: "", courseId: "" });
    } catch (err) {
      console.error(err);
      alert("Error saving student");
    }
  };

  return (
    <div className="card shadow-sm p-4 mt-4 mx-auto" style={{ maxWidth: 520 }}>
      <h4 className="text-center mb-3">{selected ? "Edit Student" : "Add Student"}</h4>
      <form onSubmit={handleSubmit}>
        <div className="mb-2">
          <label className="form-label">Name</label>
          <input name="name" className="form-control" value={form.name} onChange={handleChange} required />
        </div>
        <div className="mb-2">
          <label className="form-label">Age</label>
          <input name="age" type="number" className="form-control" value={form.age} onChange={handleChange} required />
        </div>
        <div className="mb-2">
          <label className="form-label">Grade</label>
          <input name="grade" className="form-control" value={form.grade} onChange={handleChange} />
        </div>
        <div className="mb-3">
          <label className="form-label">Course ID</label>
          <input name="courseId" type="number" className="form-control" value={form.courseId} onChange={handleChange} />
        </div>
        <button className="btn btn-success w-100" type="submit">{selected ? "Update" : "Add"}</button>
        {selected && <button type="button" className="btn btn-secondary w-100 mt-2" onClick={clearSelection}>Cancel</button>}
      </form>
    </div>
  );
}

export default StudentForm;
