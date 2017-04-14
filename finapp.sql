-- phpMyAdmin SQL Dump
-- version 4.1.6
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 14, 2017 at 06:08 AM
-- Server version: 5.6.16
-- PHP Version: 5.5.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `finapp`
--

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE IF NOT EXISTS `address` (
  `address_id` int(11) NOT NULL AUTO_INCREMENT,
  `address_1` text NOT NULL,
  `address_2` text NOT NULL,
  `landmark` text NOT NULL,
  `city` varchar(100) NOT NULL,
  `state` varchar(100) NOT NULL,
  `country` varchar(100) NOT NULL,
  `pincode` varchar(6) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  `user_id` int(11) NOT NULL,
  PRIMARY KEY (`address_id`),
  KEY `user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `articles`
--

CREATE TABLE IF NOT EXISTS `articles` (
  `article_id` int(11) NOT NULL AUTO_INCREMENT,
  `article_title` varchar(1000) NOT NULL,
  `article_description` text NOT NULL,
  `image_link` varchar(1000) NOT NULL DEFAULT 'images/article/default.jpg',
  `category_id` int(11) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`article_id`),
  KEY `category_id` (`category_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `articles`
--

INSERT INTO `articles` (`article_id`, `article_title`, `article_description`, `image_link`, `category_id`, `status`) VALUES
(1, 'First Article', 'First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.First Article.', 'images/article/default.jpg', 1, 1),
(2, 'Second Article', 'Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.Second Article.', 'images/article/default.jpg', 1, 1),
(3, 'Third Article.', 'Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.Third Article.', 'images/article/default.jpg', 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `article_categories`
--

CREATE TABLE IF NOT EXISTS `article_categories` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(1000) NOT NULL,
  `image_link` varchar(1000) NOT NULL DEFAULT 'images/category/default.jpg',
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `article_categories`
--

INSERT INTO `article_categories` (`category_id`, `category_name`, `image_link`, `status`) VALUES
(1, 'Test', 'images/category/default.jpg', 1),
(2, 'Test 2', 'images/category/default.jpg', 1);

-- --------------------------------------------------------

--
-- Table structure for table `news`
--

CREATE TABLE IF NOT EXISTS `news` (
  `news_id` int(11) NOT NULL AUTO_INCREMENT,
  `news_name` varchar(1000) NOT NULL,
  `news_link` varchar(1000) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`news_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `news`
--

INSERT INTO `news` (`news_id`, `news_name`, `news_link`, `status`) VALUES
(1, 'CNN', 'http://cnn.com', 1),
(2, 'IBN', 'http://ibn.com', 1);

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE IF NOT EXISTS `roles` (
  `role_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(1000) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `transaction_type`
--

CREATE TABLE IF NOT EXISTS `transaction_type` (
  `txn_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `txn_type_name` varchar(1000) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`txn_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(100) NOT NULL,
  `f_name` varchar(255) NOT NULL,
  `l_name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `security_question` text NOT NULL,
  `security_answer` text NOT NULL,
  `contact` varchar(20) NOT NULL,
  `dob` varchar(1000) DEFAULT '1950-01-01 00:00:00 ',
  `gender` varchar(20) DEFAULT 'Not Specified',
  `about` varchar(4000) DEFAULT 'Not Available',
  `profile_pic` varchar(1000) DEFAULT 'images/users/default.png',
  `role_id` int(10) DEFAULT '3',
  `status` int(10) NOT NULL DEFAULT '1',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `email_2` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `fk_address_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `articles`
--
ALTER TABLE `articles`
  ADD CONSTRAINT `fk_article_category` FOREIGN KEY (`category_id`) REFERENCES `article_categories` (`category_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
