using Fleck;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TinyDBTest
{
    internal class Program
    {
        private static List<IWebSocketConnection> categorySockets;
        private static List<IWebSocketConnection> commentSockets;
        private static List<IWebSocketConnection> gameSockets;
        private static List<IWebSocketConnection> platformSockets;
        private static List<IWebSocketConnection> ruleSockets;
        private static List<IWebSocketConnection> speedrunSockets;
        private static List<IWebSocketConnection> userSockets;
        private static string connectionString = @"Server=mssqlstud.fhict.local;Database=dbi512680_speedrun;User Id=dbi512680_speedrun;Password=Admin1234;TrustServerCertificate=True;";
        private static string query1 = "SELECT Id,CategoryName FROM dbo.Categories";
        private static string query2 = "SELECT Id,CommentText FROM dbo.Comments";
        private static string query3 = "SELECT Id,GameName FROM dbo.Games";
        private static string query4 = "SELECT Id,PlatformName FROM dbo.Platforms";
        private static string query5 = "SELECT Id,RuleDescription FROM dbo.Rules";
        private static string query6 = "SELECT Id,SpeedrunName FROM dbo.Runs";
        private static string query7 = "SELECT Id,Username FROM dbo.Users";
        static void Main()
        {
            categorySockets = new List<IWebSocketConnection>();
            commentSockets = new List<IWebSocketConnection>();
            gameSockets = new List<IWebSocketConnection>();
            platformSockets = new List<IWebSocketConnection>();
            ruleSockets = new List<IWebSocketConnection>();
            speedrunSockets = new List<IWebSocketConnection>();
            userSockets = new List<IWebSocketConnection>();

            var server1 = new WebSocketServer("ws://127.0.0.1:8080");
            var server2 = new WebSocketServer("ws://127.0.0.1:8081");
            var server3 = new WebSocketServer("ws://127.0.0.1:8082");
            var server4 = new WebSocketServer("ws://127.0.0.1:8083");
            var server5 = new WebSocketServer("ws://127.0.0.1:8084");
            var server6 = new WebSocketServer("ws://127.0.0.1:8085");
            var server7 = new WebSocketServer("ws://127.0.0.1:8086");
            server1.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket Opened");
                    socket.Send("hello from server");
                    categorySockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket Closed");
                    categorySockets.Remove(socket);
                };
            });
            server2.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket Opened");
                    socket.Send("hello from server");
                    commentSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket Closed");
                    commentSockets.Remove(socket);
                };
            });
            server3.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket Opened");
                    socket.Send("hello from server");
                    gameSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket Closed");
                    gameSockets.Remove(socket);
                };
            });
            server4.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket Opened");
                    socket.Send("hello from server");
                    platformSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket Closed");
                    platformSockets.Remove(socket);
                };
            });
            server5.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket Opened");
                    socket.Send("hello from server");
                    ruleSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket Closed");
                    ruleSockets.Remove(socket);
                };
            });
            server6.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket Opened");
                    socket.Send("hello from server");
                    speedrunSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket Closed");
                    speedrunSockets.Remove(socket);
                };
            });
            server7.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("WebSocket Opened");
                    socket.Send("hello from server");
                    userSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("WebSocket Closed");
                    userSockets.Remove(socket);
                };
            });

            // Connection string for your SQL Server database

            SqlDependency.Start(connectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query1, connection))
                {

                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.

                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyCategoriesChange);

                    command.ExecuteReader();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.
                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyCommentsChange);
                    command.ExecuteReader();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query3, connection))
                {
                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.
                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyGamesChange);
                    command.ExecuteReader();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query4, connection))
                {
                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.
                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyPlatformsChange);
                    command.ExecuteReader();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query5, connection))
                {
                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.
                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyRulesChange);
                    command.ExecuteReader();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query6, connection))
                {
                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.
                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyRunsChange);
                    command.ExecuteReader();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query7, connection))
                {
                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.
                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyUsersChange);
                    command.ExecuteReader();
                }
            }


            Console.WriteLine("Press Enter to exit.");

            Console.ReadLine();
        }

        // Event handler for the user OnChange event
        private static void OnDependencyCategoriesChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the notification here
            Console.WriteLine("Database change detected: " + e.Info + " " + e.Type);
            string message = "Database change detected: " + e.Info + " " + e.Type;
            foreach (var socket in categorySockets)
            {
                socket.Send(message);
            }
            SetUpSqlDependency("category", query1);
        }

        private static void OnDependencyCommentsChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the notification here
            Console.WriteLine("Database change detected: " + e.Info + " " + e.Type);
            string message = "Database change detected: " + e.Info + " " + e.Type;
            foreach (var socket in commentSockets)
            {
                socket.Send(message);
            }
            SetUpSqlDependency("comment", query2);
        }

        private static void OnDependencyGamesChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the notification here
            Console.WriteLine("Database change detected: " + e.Info + " " + e.Type);
            string message = "Database change detected: " + e.Info + " " + e.Type;
            foreach (var socket in gameSockets)
            {
                socket.Send(message);
            }
            SetUpSqlDependency("game", query3);
        }

        private static void OnDependencyPlatformsChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the notification here
            Console.WriteLine("Database change detected: " + e.Info + " " + e.Type);
            string message = "Database change detected: " + e.Info + " " + e.Type;
            foreach (var socket in platformSockets)
            {
                socket.Send(message);
            }
            SetUpSqlDependency("platform", query4);
        }

        private static void OnDependencyRulesChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the notification here
            Console.WriteLine("Database change detected: " + e.Info + " " + e.Type);
            string message = "Database change detected: " + e.Info + " " + e.Type;
            foreach (var socket in ruleSockets)
            {
                socket.Send(message);
            }
            SetUpSqlDependency("rule", query5);
        }

        private static void OnDependencyRunsChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the notification here
            Console.WriteLine("Database change detected: " + e.Info + " " + e.Type);
            string message = "Database change detected: " + e.Info + " " + e.Type;
            foreach (var socket in speedrunSockets)
            {
                socket.Send(message);
            }
            SetUpSqlDependency("speedrun", query6);
        }

        private static void OnDependencyUsersChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the notification here
            Console.WriteLine(sender);
            Console.WriteLine("Database change detected: " + e.Info + " " + e.Type);

            string message = "Database change detected: " + e.Info + " " + e.Type;
            foreach (var socket in userSockets)
            {
                socket.Send(message);
            }
            SetUpSqlDependency("user", query7);
        }

        private static void SetUpSqlDependency(string table, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);

                    // Subscribe to the SqlDependency event.
                    if (table == "user")
                    {
                        dependency.OnChange += new OnChangeEventHandler(OnDependencyUsersChange);
                    }
                    else if (table == "comment")
                    {
                        dependency.OnChange += new OnChangeEventHandler(OnDependencyCommentsChange);
                    }
                    else if (table == "category")
                    {
                        dependency.OnChange += new OnChangeEventHandler(OnDependencyCategoriesChange);
                    }
                    else if (table == "game")
                    {
                        dependency.OnChange += new OnChangeEventHandler(OnDependencyGamesChange);
                    }
                    else if (table == "platform")
                    {
                        dependency.OnChange += new OnChangeEventHandler(OnDependencyPlatformsChange);
                    }
                    else if (table == "rule")
                    {
                        dependency.OnChange += new OnChangeEventHandler(OnDependencyRulesChange);
                    }
                    else if (table == "speedrun")
                    {
                        dependency.OnChange += new OnChangeEventHandler(OnDependencyRunsChange);
                    }

                    command.ExecuteReader();
                }
            }
        }
    }
}
