# 🎨 Collaborative Drawing Board

## 📌 Overview

This project is a **web-based collaborative drawing application** where multiple users can draw together on shared boards in real time.

You can think of it as a simplified version of tools like Google Jamboard.

---

## 🚀 Core Features

### 👥 No Authentication

* No registration or login required
* Users simply enter a **nickname** to join

---

### 🗂️ Board Management

* All users see a shared list of boards immediately
* Users can:

  * Create new boards
  * Join existing boards

---

### 🤝 Real-Time Collaboration

* Multiple users can draw on the same board simultaneously
* Updates appear **almost instantly** for all users
* Implementation options:

  * WebSockets (preferred)
  * Server polling (acceptable alternative)

---

### 💾 Persistent Storage

* All drawings are saved **permanently**
* When a user joins a board later:

  * They see the full drawing history

---

## 🖥️ UI / UX

### 🖌️ Drawing Area

* Canvas fills the entire screen (except tool panel)
* Supports:

  * Responsive scaling
  * Smooth scrolling

---

### 🧰 Drawing Tools

* Multiple tools available:

  * Text
  * Rectangle
  * Circle
  * (Extendable)
* Color selection support

---

### 🧹 Editing

* Ability to **erase previously drawn elements**

---

### 🖼️ Board Preview

* Each board includes a **thumbnail preview**
* Helps users quickly identify boards

---

### 📤 Export

* Export board content as **PNG image**

---

## 🎯 Summary

This application demonstrates:

* Real-time multi-user interaction
* Persistent shared state
* Interactive canvas rendering
* Clean and responsive UI design

---

## 💡 Possible Extensions

* User cursors / presence indicators
* Undo / redo functionality
* Layer system
* Mobile optimization
