USE [master]
GO
/****** Object:  Database [TheaterTicketManagement]    Script Date: 2019/6/28 23:20:35 ******/
CREATE DATABASE [TheaterTicketManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TheaterTicketManagement', FILENAME = N'D:\TheaterTicketManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TheaterTicketManagement_log', FILENAME = N'D:\TheaterTicketManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TheaterTicketManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TheaterTicketManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TheaterTicketManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TheaterTicketManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TheaterTicketManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TheaterTicketManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TheaterTicketManagement] SET  MULTI_USER 
GO
ALTER DATABASE [TheaterTicketManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TheaterTicketManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TheaterTicketManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TheaterTicketManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TheaterTicketManagement] SET  READ_WRITE 
GO
