import { Login } from "./components/Login";
import { Home } from "./components/Home";
import Projects from "./components/Projects";
import TaskDetail from "./components/TaskDetail";
import Project from "./components/Project";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/Projects',
        element: <Projects />
    },
    {
        path: '/TaskDetail',
        element: <TaskDetail />
    },
    {
        path: '/Project',
        element: <Project />
    },
    {
        path: '/Login',
        element: <Login />
    }
];

export default AppRoutes;
