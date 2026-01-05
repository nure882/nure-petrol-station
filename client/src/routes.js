import { Navigate } from "react-router-dom";
import AdminMenu from "./pages/AdminMenu";
import Admins from "./pages/Admins";
import Coupon from "./pages/Coupon";
import Coupons from "./pages/Coupons";
import CreateCoupon from "./pages/CreateCoupon";
import CreateStation from "./pages/CreateStation";
import CreateType from "./pages/CreateType";
import Login from "./pages/Login";
import MainPage from "./pages/MainPage";
import Pump from "./pages/Pump";
import Pumps from "./pages/Pumps";
import Registration from "./pages/Registration";
import Station from "./pages/Station";
import Stations from "./pages/Stations";
import Type from "./pages/Type";
import Types from "./pages/Types";
import Workers from "./pages/Workers";
import { ADMINS_ROUTE, ADMIN_MENU_ROUTE, COUPONS_ROUTE, COUPON_ROUTE, CREATE_COUPON_ROUTE,
    CREATE_STATION_ROUTE, CREATE_TYPE_ROUTE, DEFAULT_ROUTE, LOGIN_ROUTE, MAIN_ROUTE, PUMPS_ROUTE, PUMP_ROUTE,
    REGISTRATION_ROUTE, STATIONS_ROUTE, STATION_ROUTE, TYPES_ROUTE, TYPE_ROUTE, CUSTOMERS_ROUTE, WORKERS_ROUTE, CUSTOMER_ROUTE, CREATE_PUMP_ROUTE, WORKER_ROUTE, ADMIN_ROUTE, UPDATE_STATION_ROUTE, UPDATE_PUMP_ROUTE, UPDATE_COUPON_ROUTE, UPDATE_TYPE_ROUTE, REGISTRATION_WORKER_ROUTE, ADMIN, WORKER, WORKER_MENU_ROUTE, UPDATE_WORKER_ROUTE, UPDATE_ADMIN_ROUTE } from "./utils/consts";
import Customers from "./pages/Customers";
import Customer from "./pages/Customer";
import CreatePump from "./pages/CreatePump";
import Worker from "./pages/Worker";
import Admin from "./pages/Admin";
import UpdateStation from "./pages/UpdateStation";
import UpdatePump from "./pages/UpdatePump";
import UpdateCoupon from "./pages/UpdateCoupon";
import UpdateType from "./pages/UpdateType";
import RegistrationWorker from "./pages/RegistrationWorker";
import WorkerMenu from "./pages/WorkerMenu";
import UpdateWorker from "./pages/UpdateWorker";
import UpdateAdmin from "./pages/UpdateAdmin";


export const authRoutes = [
    { path: REGISTRATION_ROUTE, component: <Registration />, role: [ADMIN] },
    { path: REGISTRATION_WORKER_ROUTE, component: <RegistrationWorker />, role: [ADMIN] },
    { path: ADMIN_MENU_ROUTE, component: <AdminMenu />, role: [ADMIN] },
    { path: WORKER_MENU_ROUTE, component: <WorkerMenu />, role: [WORKER] },

    { path: STATIONS_ROUTE, component: <Stations />, role: [ADMIN] },
    { path: STATION_ROUTE + "/:id", component: <Station />, role: [ADMIN] },
    { path: CREATE_STATION_ROUTE, component: <CreateStation />, role: [ADMIN] },
    { path: UPDATE_STATION_ROUTE + "/:id", component: <UpdateStation />, role: [ADMIN] },

    { path: TYPES_ROUTE, component: <Types />, role: [ADMIN] },
    { path: TYPE_ROUTE + "/:id", component: <Type />, role: [ADMIN] },
    { path: CREATE_TYPE_ROUTE, component: <CreateType />, role: [ADMIN] },
    { path: UPDATE_TYPE_ROUTE + "/:id", component: <UpdateType />, role: [ADMIN] },

    { path: CUSTOMERS_ROUTE, component: <Customers />, role: [ADMIN, WORKER] },
    { path: CUSTOMER_ROUTE + "/:id", component: <Customer />, role: [ADMIN, WORKER] },

    { path: WORKERS_ROUTE, component: <Workers />, role: [ADMIN] },
    { path: WORKER_ROUTE + "/:id", component: <Worker />, role: [ADMIN] },
    { path: UPDATE_WORKER_ROUTE + "/:id", component: <UpdateWorker />, role: [ADMIN] },

    { path: ADMINS_ROUTE, component: <Admins />, role: [ADMIN] },
    { path: ADMIN_ROUTE + "/:id", component: <Admin />, role: [ADMIN] },
    { path: UPDATE_ADMIN_ROUTE + "/:id", component: <UpdateAdmin />, role: [ADMIN] },

    { path: COUPONS_ROUTE, component: <Coupons />, role: [ADMIN, WORKER] },
    { path: COUPON_ROUTE + "/:id", component: <Coupon />, role: [ADMIN, WORKER] },
    { path: CREATE_COUPON_ROUTE, component: <CreateCoupon />, role: [ADMIN, WORKER] },
    { path: UPDATE_COUPON_ROUTE + "/:id", component: <UpdateCoupon />, role: [ADMIN, WORKER] },

    { path: PUMPS_ROUTE, component: <Pumps />, role: [ADMIN] },
    { path: PUMP_ROUTE + "/:id", component: <Pump />, role: [ADMIN] },
    { path: CREATE_PUMP_ROUTE, component: <CreatePump />, role: [ADMIN] },
    { path: UPDATE_PUMP_ROUTE + "/:id", component: <UpdatePump />, role: [ADMIN] },
];

export const publicRoutes = [
    { path: MAIN_ROUTE, component: <MainPage /> },
    { path: DEFAULT_ROUTE, component: <Navigate to={MAIN_ROUTE}/> },
    { path: LOGIN_ROUTE, component: <Login /> },
];