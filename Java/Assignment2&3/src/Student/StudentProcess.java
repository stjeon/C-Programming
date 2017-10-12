package Student;

import java.text.DecimalFormat;
import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;
import java.util.TreeSet;
import java.util.function.Consumer;
import java.util.function.BiConsumer;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Stream;
import java.util.stream.Collectors;
import java.util.stream.DoubleStream;
import java.util.Optional;
import java.util.Set;

public class StudentProcess {

	public static void main(String[] args) {
		Student[] students = {
				new Student("Jack", "Smith", 50.0, "IT"),
				new Student("Aaron", "Johnson", 76.0, "IT"),
				new Student("Maaria", "White", 35.8, "Business"),
				new Student("John", "White", 47.0, "Media"),
				new Student("Laney", "White", 62.0, "IT"),
				new Student("Jack", "Jones", 32.9, "Business"),
				new Student("Wesley", "Jones", 42.89, "Media")};
		
		//task1(students);
		//task2(students);
		task3(students);
		//task4(students);
		task5(students);
		task6(students);
		task7(students);
		task8(students);
		task9(students);
		task10(students);

	}
	
	//Task 1
	public static Stream<Student> task1(Student [] students){
		// Throw the students array into a list and return it as a stream
		List <Student> l = Arrays.asList(students);
		System.out.println("Task 1:");
		System.out.println("Complete Student list:");
		System.out.println(Arrays.toString(students));
		Stream <Student>over50= l.stream();
		System.out.println("\n");
		
		return over50;
	}
	
	//Task 2
	public static Stream<Student> task2(Student [] students){
		//filter method reference from task 1 to a new list
		List <Student> over50 = task1(students)
		.filter(b -> b.getGrade() >=50)		
		.collect(Collectors.toList());
		//sort grades in ascending order using comparator
		Collections.sort(over50, (g1,g2)-> Double.compare(g1.getGrade(), g2.getGrade()));  
		//print out all relevant data
		System.out.println("Task 2:");
		System.out.println("Students who got 50.0-100.0 sorted by grade:");
		System.out.println(over50);
		//set a new stream with the filtered values and return it
		Stream <Student> endresult = over50.stream();
		System.out.println("\n");
		
		return endresult;
	}
	
	//Task 3
	public static Stream<Student> task3(Student [] students){
		//Retrieve task2 results and throw it into a list
		List<Student> firstS = task2(students)
				.collect(Collectors.toList());
		//Store the first result only in a new student object
		Student first =  firstS.get(0);		
		//store the end result to return it
		Stream <Student> endresult =  firstS.stream();
		
		System.out.println("Task 3:");
		System.out.println("First Student who got 50.0-100.0:");
		System.out.println(first);
		System.out.println("\n");
		
		return endresult;		
	}
	
	//Task 4
	public static Stream<Student> task4(Student [] students){
		//fresh list of students for operations
		List <Student> l = Arrays.asList(students);
		//Throw the list into a comparator for double sorting
		//Ascending order
		Comparator<Student> ascending = Comparator.comparing(Student -> Student.getLastName());
		ascending = ascending.thenComparing(Comparator.comparing(Student -> Student.getFirstName()));
		//Descending order
				//Return the list into a stream and sort it
		Stream<Student> StudentAscending = l.stream().sorted(ascending);	
		Stream<Student> StudentDescending = l.stream().sorted(ascending.reversed());	
		//Throw the stream into a list for printing
		List<Student> list = StudentAscending.collect(Collectors.toList());
		List<Student> list2 = StudentDescending.collect(Collectors.toList());
		System.out.println("Task 4:");
		System.out.println("Students in ascending order by last name then first:");
		System.out.println(list);
		System.out.println("Students in descending order by last name then first:");
		System.out.println(list2);
		System.out.println("\n");
		
		Stream <Student> endresult =  l.stream();
		
		return endresult;
	}
	
	//Task 5
	public static Stream<String> task5(Student [] students){
		//Retrieve a stream of strings from the previous task
		Stream<String> u = task4(students)
				//Map it by last name and return distinct values sorted
				.map(student -> student.getLastName()).distinct().sorted();
		//throw the output into a list for printing
		List <String> fin = u.collect(Collectors.toList());
		
		System.out.println("Task 5:");
		System.out.println("Unique Student last names:");
		System.out.println(fin+ "\n");
		
		return u;
		
	}
	
	//Task 6
	public static Stream<Student> task6(Student [] students){
		//Set comparators for last name and first name fields
		Comparator <Student> compareLastName = Comparator.comparing(Student -> Student.getLastName());
		Comparator <Student> compareFirstName = Comparator.comparing(Student -> Student.getFirstName());
		//Retrieve the stream of students and compare them by last name then first name
		Stream <Student> t4 = task4(students)
				.sorted(compareLastName.thenComparing(compareFirstName));
		//throw the results into a list
		List<Student> t4list= t4.collect(Collectors.toList());
		
		System.out.println("Task 6:");
		System.out.println("Student names in order by last name then first name:");
		//Print each elements first and last names using the get name method of class Student
		t4list.forEach(s -> System.out.println(s.getName()+ "\n"));
		System.out.println("\n");
		
		return t4;
		
	}
	
	//Task 7
	public static void task7(Student [] students){
		//Initial list of students
		List <Student> initial=Arrays.asList(students);
		//Map the list by department and print
		Map<Object, List<Student>> t7= initial.stream().collect(Collectors.groupingBy(Student ->Student.getDepartment()));
		System.out.println("Task 7:");
		System.out.println("Students by department:");
		System.out.println(t7);
		System.out.println("\n");
			
	}
	
	//Task 8
	public static void task8(Student [] students){
		//Initial list of students
		List <Student> initial=Arrays.asList(students);
		//Map the list of students into a map and collect by department
		Map<Object, List<Student>> t8=initial.stream().collect(Collectors.groupingBy(Student -> Student.getDepartment()));
		//Print each department and the count of students in each department
		System.out.println("Task 8:");
		System.out.println("Count of Students by department:");
		t8.forEach((department, Student)->System.out.println(department + " has "+ Student.size() + " Student(s)"));
		System.out.println("\n");
	}
	
	//Task 9
	public static double task9(Student [] students){
		//Initial list of students
		List <Student> initial=Arrays.asList(students);
		//Map the output by each students' grades and calculate the sum
		double grades=initial.stream().mapToDouble(Student->Student.getGrade()).sum();
		System.out.println("Task 9:");
		System.out.println("Sum of Students' grade:" + grades + "\n");
		
		return grades;
	}
	
	//Task10
	public static double task10(Student [] students){
		System.out.println("Task 10:");
		System.out.println("Average of Students grades:");
		//Take initial list
		List <Student> initial=Arrays.asList(students);
		//map to double by grades and return the average as a double
		double gradesavg=initial.stream().mapToDouble(Student->Student.getGrade()).average().getAsDouble();
		//Format the final output into a string
		String gradesavgfin =new DecimalFormat("#0.00").format(gradesavg);
		System.out.println(gradesavgfin);
		
		return gradesavg;
	}
}
