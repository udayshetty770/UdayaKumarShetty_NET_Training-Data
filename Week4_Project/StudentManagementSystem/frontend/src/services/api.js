const API_BASE_URL = "http://localhost:5205/api/Students";

export async function getStudents() {
  const r = await fetch(API_BASE_URL);
  return r.json();
}


export async function addStudent(student) {
  return await fetch(API_BASE_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(student),
  });
}

export async function updateStudent(id, student) {
  return await fetch(`${API_BASE_URL}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(student),
  });
}

export async function deleteStudent(id) {
  return await fetch(`${API_BASE_URL}/${id}`, {
    method: "DELETE",
  });
}
