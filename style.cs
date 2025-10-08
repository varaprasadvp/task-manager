:root{
  --bg:#f7fafc;
  --card:#ffffff;
  --muted:#6b7280;
  --accent:#2563eb;
  --danger:#dc2626;
  --success:#16a34a;
  --radius:12px;
  --shadow: 0 6px 18px rgba(15,23,42,0.08);
  font-family: Inter, system-ui, -apple-system, "Segoe UI", Roboto, "Helvetica Neue", Arial;
}

*{box-sizing:border-box}
html,body{height:100%}
body{
  margin:0;
  background:linear-gradient(180deg,var(--bg),#ffffff);
  color:#0f172a;
  -webkit-font-smoothing:antialiased;
  -moz-osx-font-smoothing:grayscale;
  line-height:1.4;
  padding:24px;
  display:flex;
  flex-direction:column;
  min-height:100vh;
}

.app-header{
  text-align:center;
  margin-bottom:18px;
}
.app-header h1{
  margin:0;
  font-size:1.6rem;
}
.subtitle{
  margin:6px 0 0 0;
  color:var(--muted);
  font-size:0.95rem;
}

.container{
  width:100%;
  max-width:900px;
  margin:0 auto;
  background:var(--card);
  border-radius:var(--radius);
  padding:18px;
  box-shadow:var(--shadow);
}

.task-input input, .task-input textarea{
  width:100%;
  padding:10px 12px;
  border-radius:8px;
  border:1px solid #e6e6e6;
  margin-bottom:10px;
  font-size:0.98rem;
  outline:none;
}
.task-input textarea { resize:vertical; min-height:48px; }

.form-row{
  display:flex;
  gap:10px;
  justify-content:flex-end;
}

.btn{
  padding:10px 14px;
  border-radius:10px;
  border:1px solid #d1d5db;
  background:transparent;
  cursor:pointer;
  font-weight:600;
}
.btn.primary{
  background:var(--accent);
  color:white;
  border:none;
}
.btn.danger{
  background:transparent;
  color:var(--danger);
  border-color:rgba(220,38,38,0.08);
}

.progress-section{margin:12px 0 18px 0}
.progress-info{
  display:flex;
  justify-content:space-between;
  font-size:0.95rem;
  color:var(--muted);
  margin-bottom:8px;
}
.progress-bar{
  width:100%;
  height:14px;
  background:#eef2ff;
  border-radius:10px;
  overflow:hidden;
}
.progress-fill{
  height:100%;
  background:linear-gradient(90deg,var(--accent), #7c3aed);
  width:0%;
  transition:width 300ms ease;
}

.tasks-list{list-style:none;padding:0;margin:0;display:flex;flex-direction:column;gap:10px}
.task-item{
  display:flex;
  gap:12px;
  align-items:flex-start;
  padding:12px;
  border-radius:10px;
  background:#fbfdff;
  border:1px solid #f1f5f9;
}
.task-left{display:flex;gap:10px;align-items:center;width:100%}
.checkbox{
  width:22px;height:22px;border-radius:6px;border:1px solid #d1d5db;display:inline-flex;align-items:center;justify-content:center;cursor:pointer;
}
.checkbox.checked{background:var(--success);border-color:rgba(22,163,74,0.9);color:white}
.task-meta{flex:1}
.task-meta h4{margin:0 0 6px 0;font-size:1rem}
.task-meta p{margin:0;color:var(--muted);font-size:0.92rem}
.task-actions{display:flex;gap:8px;align-items:center}
.icon-btn{background:transparent;border:none;cursor:pointer;padding:6px;border-radius:6px}
.small-muted{font-size:0.85rem;color:var(--muted)}

.no-tasks{text-align:center;color:var(--muted);padding:18px}

.app-footer{text-align:center;margin-top:14px;color:var(--muted);font-size:0.85rem}

/* dialog styles */
edit-dialog, dialog { border:none; padding:0; }
.edit-dialog::backdrop{ background:rgba(2,6,23,0.4) }
#edit-form{ padding:16px; width:min(420px,92vw); display:flex; flex-direction:column; gap:10px; background:white; border-radius:10px }
.dialog-actions{ display:flex; gap:8px; justify-content:flex-end; border:none; padding:0; margin-top:6px }

/* Responsive */
@media (max-width:600px){
  .form-row{flex-direction:column; align-items:stretch;}
  .task-input input, .task-input textarea{font-size:0.95rem}
}
