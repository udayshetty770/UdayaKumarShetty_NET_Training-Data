import React, { useState, useEffect } from "react";
import StudentForm from "./components/StudentForm";
import StudentList from "./components/StudentList";
import { getStudents } from "./services/api";
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";

function App() {
  const [students, setStudents] = useState([]);
  const [selected, setSelected] = useState(null);
  const [loading, setLoading] = useState(false);

  const fetchStudents = async () => {
    setLoading(true);
    try {
      const data = await getStudents();
      setStudents(data);
    } catch (err) {
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => { fetchStudents(); }, []);

  return (
    <div className="container py-5">
      <h2 className="text-center text-primary mb-4">Student Management System</h2>
      <StudentForm selected={selected} refreshList={fetchStudents} clearSelection={() => setSelected(null)} />
      {loading ? <p className="text-center mt-3">Loading...</p> :
        <StudentList students={students} onEdit={(s) => setSelected(s)} refreshList={fetchStudents} />}
    </div>
  );
}

export default App;
