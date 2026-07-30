# 🎉 PartyNL

**PartyNL** is a cross-platform mobile application that helps people discover events, festivals, parties, concerts, exhibitions, and activities across the Netherlands.

Instead of searching through dozens of websites, users can open one interactive map and instantly see what is happening nearby.

---

## ✨ Vision

> Never ask **"What should we do tonight?"** again.

PartyNL combines event discovery, interactive maps, AI recommendations, and social planning into a single experience.

---

## 🚀 Features (MVP)

- 📍 Interactive event map
- 🎉 Event discovery
- ❤️ Save favorite events
- 👥 Mark attendance
- 🏢 Organizer accounts
- 🔍 Category filtering
- 🤖 AI event recommendations

---

## 🛠 Tech Stack

### Mobile

- React Native
- Expo
- TypeScript

### Backend

- ASP.NET Core 9
- Entity Framework Core
- PostgreSQL

### Authentication

- Firebase Authentication

### Maps

- Google Maps Platform

### Cloud

- Microsoft Azure

---

## 📂 Project Structure

```text
PartyNL
│
├── apps/
│   └── mobile
│
├── backend/
│   ├── PartyNL.API
│   ├── PartyNL.Application
│   ├── PartyNL.Domain
│   ├── PartyNL.Infrastructure
│   └── PartyNL.Persistence
│
├── docs/
│
└── design/
```

---

## 🏗 Architecture

The backend follows **Clean Architecture**.

```
Presentation (API)
        │
Application
        │
Domain
        │
Infrastructure
        │
Persistence
```

The Domain layer contains business rules.

Infrastructure contains external services.

Persistence manages PostgreSQL through Entity Framework Core.

API exposes REST endpoints.

---

## 📅 Roadmap

- [x] Repository setup
- [x] Clean Architecture
- [x] Backend initialization
- [x] Health endpoint
- [x] Domain structure
- [ ] Domain entities
- [ ] PostgreSQL integration
- [ ] Initial migration
- [ ] Authentication
- [ ] Event management
- [ ] Google Maps
- [ ] AI assistant

---

## 👩‍💻 Authors

Developed as a software engineering project by the PartyNL team.
