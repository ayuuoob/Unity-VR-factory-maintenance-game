# Factory Maintenance VR

A data-driven Virtual Reality (simulated VR) application developed using **Unity 2022.3 LTS**.

This project simulates a factory maintenance system where the player must supervise and repair malfunctioning machines within a limited time.

---

## 🎮 Game Concept

The player is placed inside a virtual factory using a **first-person perspective**.
Each machine can enter different operational states and requires specific actions to be fixed.

The objective is to fix all machines before the timer reaches zero.

---

## 🛠 Machine States

- 🟢 **Green (Working)**: Machine is operating normally
- 🟠 **Orange (Warning)**: Machine requires a restart
- 🔴 **Red (Error)**: Machine requires a repair (two actions)

All machines start in a warning or error state.

---

## 🎯 Controls

- **Mouse Click**: Select a machine  
- **A**: Restart a warning (orange) machine  
- **E**: Repair an error (red) machine (two actions required)

---

## ⏱ Game Rules

- The player has **60 seconds** to fix all machines
- Fix all machines → **WIN**
- Time runs out → **LOSE**
- A restart option is available at the end of the game

---

## 🧠 Technologies Used

- **Unity 2022.3 LTS**
- **C#**
- **First-Person Controller**
- **Simulated VR (no headset required)**

---

## 🏗 Project Architecture

- `GameManager` — controls game flow, timer, win/lose logic, UI, restart
- `Machine` — manages machine state and visual feedback
- `InteractionManager` — handles player-machine interaction
- `MouseComponent` — controls first-person camera movement

---

## 👥 Team Members

- FAKRAOUI Ayoub  
- ENNEYA Imane

  --

## 📁 How to Open the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/USERNAME/Factory-Maintenance-VR.git
