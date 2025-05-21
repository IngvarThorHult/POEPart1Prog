# Cybersecurity Awareness Bot

A **C# console application** that helps users learn about cybersecurity in a fun and interactive way! The bot can respond to keyword-based questions, offer tips, share news, run quizzes, and more. It also plays an audio greeting and displays ASCII art to enhance user engagement.

---

## 🛡 Features

- **Keyword Detection** – Smart responses to terms like "password", "scam", "privacy", and more.
- **Interactive Dialogue** – Understands user sentiment (e.g., worried, curious, frustrated).
- **Topic Tracking** – Remembers user interests for follow-up responses.
- **Phishing Tips** – Shares randomized safety tips to avoid phishing.
- **Quiz Mode** – Short quiz to test your cybersecurity knowledge.
- **Checklists & Myths** – Provides a checklist of security habits and busts common myths.
- **News Simulation** – Lists fictional cybersecurity news headlines.
- **Audio Welcome** – Plays a greeting sound using `NAudio`.

---

## 🧰 Requirements

- [.NET SDK](https://dotnet.microsoft.com/download)
- [NAudio](https://github.com/naudio/NAudio) library for audio playback

Install NAudio via NuGet:

```bash
dotnet add package NAudio
