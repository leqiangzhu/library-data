-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Sep 28, 2018 at 01:00 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `library_data`
--

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `book_id` int(11) NOT NULL,
  `book_name` varchar(255) NOT NULL,
  `author_id` int(11) NOT NULL,
  `book_copies` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `book_name`, `author_id`, `book_copies`) VALUES
(4, 'JAVA IS NOT BAD', 1, 2),
(5, 'C# is GOOD', 2, 3),
(6, 'HOW TO LEARN C#', 2, 20),
(10, 'HOW TO LEARN JAVA', 2, 100),
(11, 'HOW TO LEARN C#', 2, 20),
(12, 'Three Kingdoms', 5, 4),
(13, 'Three Kingdoms2', 5, 6),
(14, 'Three Kingdoms2', 5, 6),
(15, 'Harry Potter and the Sorcerer\'s Stone', 4, 0);

-- --------------------------------------------------------

--
-- Table structure for table `copies`
--

CREATE TABLE `copies` (
  `book_id` int(11) NOT NULL,
  `book_copies` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `copies`
--

INSERT INTO `copies` (`book_id`, `book_copies`) VALUES
(1, 4),
(2, 6),
(3, 6),
(4, 0);

-- --------------------------------------------------------

--
-- Table structure for table `patrons`
--

CREATE TABLE `patrons` (
  `patron_id` int(11) NOT NULL COMMENT '1',
  `patron_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `patrons`
--

INSERT INTO `patrons` (`patron_id`, `patron_name`) VALUES
(1, 'FRANK'),
(2, 'DAVID'),
(5, 'TOM'),
(6, 'Daisy'),
(9, 'Nancy'),
(10, 'Sara'),
(11, 'Fany'),
(12, 'ANGELA'),
(13, 'Jane');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`book_id`);

--
-- Indexes for table `copies`
--
ALTER TABLE `copies`
  ADD PRIMARY KEY (`book_id`);

--
-- Indexes for table `patrons`
--
ALTER TABLE `patrons`
  ADD PRIMARY KEY (`patron_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `copies`
--
ALTER TABLE `copies`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `patrons`
--
ALTER TABLE `patrons`
  MODIFY `patron_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '1', AUTO_INCREMENT=14;