document.write(
"<li class=\"header\">MAIN NAVIGATION</li>" +
"                        <li class=\"active\">" +
"                            <a href=\"@Url.Action(\"advisor\", \"advisor\")\">" +
"                                <i class=\"material-icons\">home</i>" +
"                                <span>Home</span>" +
"                            </a>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"javascript:void(0);\" class=\"menu-toggle\">" +
"                                <i class=\"material-icons\">content_copy</i>" +
"                                <span>Student</span>" +
"                            </a>" +
"                            <ul class=\"ml-menu\">" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"studentlist\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Details</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"uploadstudent\", \"uploadstudent\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Upload</span>" +
"                                    </a>" +
"                                </li>" +
"                            </ul>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"javascript:void(0);\" class=\"menu-toggle\">" +
"                                <i class=\"material-icons\">content_copy</i>" +
"                                <span>Theory Attendance</span>" +
"                            </a>" +
"                            <ul class=\"ml-menu\">" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"attendancelist\")\">" +
"                                        <i class=\"material-icons\">add_circle</i>" +
"                                        <span>New</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Edit\", \"attendancelist\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Edit</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Details\", \"attendancelist\")\">" +
"                                        <i class=\"material-icons\">view_list</i>" +
"                                        <span>View</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"total\", \"attendancelist\")\">" +
"                                        <i class=\"material-icons\">view_list</i>" +
"                                        <span>Total</span>" +
"                                    </a>" +
"                                </li>" +
"                            </ul>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"javascript:void(0);\" class=\"menu-toggle\">" +
"                                <i class=\"material-icons\">content_copy</i>" +
"                                <span>Practical Attendance</span>" +
"                            </a>" +
"                            <ul class=\"ml-menu\">" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"practicalattendancelist\")\">" +
"                                        <i class=\"material-icons\">add_circle</i>" +
"                                        <span>New</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Edit\", \"practicalattendancelist\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Edit</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Details\", \"practicalattendancelist\")\">" +
"                                        <i class=\"material-icons\">view_list</i>" +
"                                        <span>View</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"total\", \"practicalattendancelist\")\">" +
"                                        <i class=\"material-icons\">view_list</i>" +
"                                        <span>Total</span>" +
"                                    </a>" +
"                                </li>" +
"                            </ul>" +
"                        </li>"
);