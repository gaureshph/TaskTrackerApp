import { Link } from "react-router-dom";
import { SidebarWrapper } from "./Sidebar.styles";
import { formatDateAsDDMMYYYY } from "../../../Utilities/DateUtilities";

const Sidebar = () => {
  const todayDate = new Date();
  const tomorrowDate = new Date();
  tomorrowDate.setDate(todayDate.getDate() + 1);
  const nextWeekDate = new Date();
  nextWeekDate.setDate(todayDate.getDate() + 7);

  const navItems = [
    {
      key: "today",
      label: "Today",
      path: `/day/${formatDateAsDDMMYYYY(todayDate)}`,
    },
    {
      key: "tomorrow",
      label: "Tomorrow",
      path: `/day/${formatDateAsDDMMYYYY(tomorrowDate)}`,
    },
    {
      key: "currentweek",
      label: "Current Week",
      path: `/week/${formatDateAsDDMMYYYY(todayDate)}`,
    },
    {
      key: "nextweek",
      label: "Next Week",
      path: `/week/${formatDateAsDDMMYYYY(nextWeekDate)}`,
    },
    {
      key: "month",
      label: "Month",
      path: `/month/${formatDateAsDDMMYYYY(todayDate)}`,
    },
    {
      key: "year",
      label: "Year",
      path: `/year/${formatDateAsDDMMYYYY(todayDate)}`,
    },
  ];

  return (
    <SidebarWrapper>
      {navItems.map((item) => (
        <Link key={item.key} to={item.path}>
          {item.label}
        </Link>
      ))}
    </SidebarWrapper>
  );
};

export default Sidebar;
