const students =[
    {"name": "Mariq", "age": 18, "grade": 5.50, "city": "Razgrad"},
    {"name": "Ivan", "age": 17, "grade": 4.20, "city": "Varna"},
    {"name": "Valq", "age": 16, "grade": 6.00, "city": "Sofiya"},
    {"name": "Sofia", "age": 14, "grade": 3.60, "city": "Razgrad"},
    {"name": "Miro", "age": 19, "grade": 5.00, "city": "Ruse"}
];

const sudentGrid = document.getElementById("studentGrid");

function renderSudents(data){
   sudentGrid.innerHTML = data.map(s=>{
  `<div class="student-card">
                <h3>Име:${s.name}</h3>
                <p>Възраст:${s.age}</p>
                <p>Успех:${s.grade}</p>
                <p>Град:${s.city}</p>
            </div>
   `}).join("");  
    
}

document.getElementById("allBtn").addEventListener(onclick= ()=>{
    renderSudents(students);
})