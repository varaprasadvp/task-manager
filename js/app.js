// Select elements
const taskForm = document.getElementById("task-form");
const taskTitle = document.getElementById("task-title");
const taskDesc = document.getElementById("task-desc");
const tasksList = document.getElementById("tasks-list");
const noTasksMsg = document.getElementById("no-tasks");
const clearAllBtn = document.getElementById("clear-all");
const progressText = document.getElementById("progress-text");
const progressPercent = document.getElementById("progress-percent");
const progressFill = document.getElementById("progress-fill");

// Edit modal elements
const editDialog = document.getElementById("edit-dialog");
const editTitle = document.getElementById("edit-title");
const editDesc = document.getElementById("edit-desc");
const saveEditBtn = document.getElementById("save-edit");
const cancelEditBtn = document.getElementById("cancel-edit");

let tasks = JSON.parse(localStorage.getItem("tasks")) || [];
let editIndex = null;

function renderTasks() {
  tasksList.innerHTML = "";
  if (tasks.length === 0) {
    noTasksMsg.style.display = "block";
  } else {
    noTasksMsg.style.display = "none";
    tasks.forEach((task, index) => {
      const li = document.createElement("li");
      li.className = "task-item";
      li.innerHTML = `
        <div class="task-left">
          <div class="checkbox ${task.completed ? "checked" : ""}" data-index="${index}">
            ${task.completed ? "✓" : ""}
          </div>
          <div class="task-meta">
            <h4>${task.title}</h4>
            ${task.desc ? `<p>${task.desc}</p>` : ""}
          </div>
        </div>
        <div class="task-actions">
          <button class="icon-btn edit-btn" data-index="${index}" title="Edit">✏️</button>
          <button class="icon-btn delete-btn" data-index="${index}" title="Delete">🗑️</button>
        </div>
      `;
      tasksList.appendChild(li);
    });
  }
  updateProgress();
  saveTasks();
}

function updateProgress() {
  const total = tasks.length;
  const completed = tasks.filter(t => t.completed).length;
  const percent = total ? Math.round((completed / total) * 100) : 0;
  progressText.textContent = `${completed} of ${total} completed`;
  progressPercent.textContent = `${percent}%`;
  progressFill.style.width = `${percent}%`;
}

function saveTasks() {
  localStorage.setItem("tasks", JSON.stringify(tasks));
}

taskForm.addEventListener("submit", e => {
  e.preventDefault();
  const title = taskTitle.value.trim();
  const desc = taskDesc.value.trim();
  if (!title) return;
  tasks.push({ title, desc, completed: false });
  taskTitle.value = "";
  taskDesc.value = "";
  renderTasks();
});

tasksList.addEventListener("click", e => {
  if (e.target.classList.contains("checkbox")) {
    const i = e.target.dataset.index;
    tasks[i].completed = !tasks[i].completed;
    renderTasks();
  }
  if (e.target.classList.contains("edit-btn")) {
    editIndex = e.target.dataset.index;
    const task = tasks[editIndex];
    editTitle.value = task.title;
    editDesc.value = task.desc;
    editDialog.showModal();
  }
  if (e.target.classList.contains("delete-btn")) {
    const i = e.target.dataset.index;
    tasks.splice(i, 1);
    renderTasks();
  }
});

saveEditBtn.addEventListener("click", e => {
  e.preventDefault();
  if (editIndex === null) return;
  const title = editTitle.value.trim();
  const desc = editDesc.value.trim();
  if (!title) return;
  tasks[editIndex].title = title;
  tasks[editIndex].desc = desc;
  editIndex = null;
  editDialog.close();
  renderTasks();
});

cancelEditBtn.addEventListener("click", () => {
  editDialog.close();
  editIndex = null;
});

clearAllBtn.addEventListener("click", () => {
  if (confirm("Delete all tasks?")) {
    tasks = [];
    renderTasks();
  }
});

renderTasks();

